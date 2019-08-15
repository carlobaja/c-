using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudEntity.Models;
using System.Data.Entity;

namespace CrudEntity.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var templateBanners = new List<TemplateBanners>()
            {
                new TemplateBanners {TemplateName="this_is_templateName1",Path="this_is_path1"},
                new TemplateBanners {TemplateName="this_is_templateName2",Path="this_is_path2"},
                new TemplateBanners {TemplateName="this_is_templateName3",Path="this_is_path3"}
            };
            templateBanners.ForEach (t => context.TemplateBanners.Add(t));
            context.SaveChanges();

            var bannerTemplates = new List<BannerTemplate>()
            {

                new BannerTemplate {Name="this_is_templateName1"},
                new BannerTemplate {Name="this_is_templateName2"}
    
            };
            bannerTemplates.ForEach(b => context.BannerTemplates.Add(b));
            context.SaveChanges();

            var image = new List<Image>()
            {

                new Image {Name="this_is_Image1",InvocationCode = "This_is_invocation1"},
                new Image {Name="this_is_Image2",InvocationCode = "This_is_invocation2"}

            };
            image.ForEach(b => context.Images.Add(b));
            context.SaveChanges();

            var video = new List<Video>()
            {

                new Video {Name="this_is_video1",Link = "This_is_link1"},
                new Video {Name="this_is_video2",Link = "This_is_link2"}

            };
            video.ForEach(b => context.Videos.Add(b));
            context.SaveChanges();
        }
    }
}