using BlogWebApplicationEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplicationEntities.Concrete
{
    public class Writer:IEntity
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public string WriterTwitter { get; set; }
        public string WriterInstagram { get; set; }
        public string WriterLinkedin{ get; set; }
        public List<Blog> Blogs { get; set; }
        public bool IsActive { get; set; }

    }
}
