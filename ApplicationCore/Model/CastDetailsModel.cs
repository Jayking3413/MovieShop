using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    public class CastDetailsModel
    {
        public CastDetailsModel()
        {
            Cards = new List<MovieCardModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }
        public string Gender { get; set; }
        public string Character { get; set; }

        public List<MovieCardModel> Cards { get; set; }
    }
}
