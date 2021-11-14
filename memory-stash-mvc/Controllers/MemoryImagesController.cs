using Firebase.Auth;
using Firebase.Storage;
using memory_stash_mvc.Data;
using memory_stash_mvc.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;


namespace memory_stash_mvc.Controllers
{

    public class MemoryImagesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        //private static string ApiKey = "AIzaSyAZPQuAECwpuNchHgQvz9orX0yveOEbV_c";
        //private static string Bucket = "memory-stash.appspot.com";
        //private static string AuthEmail = "asdf@gmail.com";
        //private static string AuthPassword = "asdf123";

        public MemoryImagesController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(MemoryImage memoryImage)
        {
            //Stream stream;

            //if (file.Length > 0)
            //{
            //    string path = Path.Combine(Server.MapPath("~/Content/images/"), file.FileName);
            //    file.SaveAs(path)

            //    stream = file.OpenReadStream();
            //    await Task.Run(() => upload(stream, file.FileName));

            //}
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(memoryImage.ImageFile.FileName);
                string extension = Path.GetExtension(memoryImage.ImageFile.FileName);
                memoryImage.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await memoryImage.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(memoryImage);
                await _context.SaveChangesAsync();
                
            }

            return Redirect("/Memories/Edit/" + memoryImage.MemoryId);
        }


        //private async void upload(Stream stream, string fileName)
        //{
           
        //    // of course you can login using other method, not just email+password
        //    var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
        //    var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

        //    // you can use CancellationTokenSource to cancel the upload midway
        //    var cancellation = new CancellationTokenSource();

        //    var task = new FirebaseStorage(
        //        Bucket,
        //        new FirebaseStorageOptions
        //        {
        //            AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
        //            ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
        //        })
        //        .Child("mages")
        //        .Child(fileName)
        //        .PutAsync(stream, cancellation.Token);

        //    task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

        //    // cancel the upload
        //    // cancellation.Cancel();

        //    try
        //    {
        //        // error during upload will be thrown when you await the task
        //        Console.WriteLine("Download link:\n" + await task);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception was thrown: {0}", ex);
        //    }

        //}
    }
}
