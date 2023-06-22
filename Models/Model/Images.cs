using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Images
    {
        public string Flag { get; set; }
        public string Image { get; set; } //BASE64
        public List<ImageInfo> Values { get; set; }
    }

    public class ImageInfo
    {
        public string Image { get; set; }
        
    }

}
