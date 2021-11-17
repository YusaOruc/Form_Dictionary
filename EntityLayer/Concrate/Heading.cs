﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadigDate { get; set; }
        public bool HeadingStatus { get; set; }

        //Çok ilişki//
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        //Çok ilişki//


        //Bir İlişki//
        public ICollection<Content> Contents { get; set; }
        //Bir İlişki//


        //Çok ilişki//
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }
        //Çok ilişki//

    }
}
