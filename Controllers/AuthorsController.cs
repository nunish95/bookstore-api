using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
       private readonly BookstoreContext db;
       public AuthorsController(BookstoreContext db){
           this.db = db;

           if (this.db.Authors.Count() == 0)
           {
               this.db.Authors.Add(new Author
                {
                   Id = 1,
                   Name = "Anqi Yang"
               });

               this.db.Authors.Add(new Author
               {
                   Id=2,
                   Name="Helen Keller"

               });
               this.db.SaveChanges();
           }
       }
       [HttpGet]
       public IActionResult GetAll()
       {return Ok(db.Authors);
       }
       [HttpGet("{id}",Name="GetAuthor")]
       public IActionResult GetById(int id){
           var Author =db.Authors.Find(id);
           if(Author==null){
               return NotFound();
           }
           return Ok(Author);
       }
       
       [HttpPost]
       public IActionResult Post([FromBody]Author Author){
           if(Author==null){
               return BadRequest();
           }
           this.db.Authors.Add(Author);
           this.db.SaveChanges();

           return CreatedAtRoute("GetAuthor",new { id = Author.Id},Author);
       }
       [HttpPut("{id}")]
       public IActionResult Put(int id,[FromBody]Author newAuthor)
       {
           if (newAuthor == null || newAuthor.Id !=id){
               return BadRequest();
           }
           var currentAuthor = this.db.Authors.FirstOrDefault(x =>x.Id ==id);
           if (currentAuthor ==null){
               return NotFound();
           }
           currentAuthor.Name=newAuthor.Name;
          
           
           this.db.Authors.Update(currentAuthor);
           this.db.SaveChanges();

           return NoContent();
       }
       [HttpDelete("{id}")]
       public IActionResult Delet (int id){
           var Author =this.db.Authors.FirstOrDefault(x => x.Id ==id);
           if (Author ==null){
               return NotFound();
           }
           this.db.Authors.Remove(Author);
           this.db.SaveChanges();
           return NoContent();}
    }
}