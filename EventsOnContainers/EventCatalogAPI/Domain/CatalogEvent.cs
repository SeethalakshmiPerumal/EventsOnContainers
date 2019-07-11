using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class CatalogEvent
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string ContactName { get; set;}
        public long ContactNum { get; set; }
        

        //foreign keys
        public int CatalogLocationId { get; set; }
        public virtual CatalogLocation CatalogLocation { get; set; }
    }
}
