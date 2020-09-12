using System;
using System.Collections.Generic;
using System.Text;

namespace Sample05
{
   public class Comment
    {
        public string id { get; set; }//主键
        public int content_id { get; set; }//文章ID
        public string content { get; set; }
        public DateTime add_time { get; set; } = DateTime.Now;
    }
}
