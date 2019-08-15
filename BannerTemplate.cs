using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudEntity.Models
{
    public class BannerTemplate
    {
        [Key]      
        public int Id { get; set; }
        public string Name { get; set; }
        public TemplateBanners TemplateBanner { get; set; }
        //public IEnumerable <SelectListItem> SelectedTemplates { get; set; }
    }
    public class TemplateBanners
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public string Path { get; set; }      
    }
    [Table ("ImageTable")]
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InvocationCode { get; set; }
        public virtual TemplateBanners TemplateBanners { get; set; }
    }
    [Table("VideoTable")]
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }       
        public virtual TemplateBanners TemplateBanners { get; set; }
        
    }
}