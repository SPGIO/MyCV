using MyCV.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models
{
    public class ImageFile
    {   
        public int Id { get; set; }
        [Image]
        public byte[] Content { get; set; }


        public string ConvertToString()
        {
           if(Content.Length == 0)
            {
                return "~/Images/cvicon.png";
            }
            else
            {
            var base64 = Convert.ToBase64String(Content);
            var imgSrc = $"data:image/png;base64,{base64}";
            return imgSrc;
            }
        }
    }
}
