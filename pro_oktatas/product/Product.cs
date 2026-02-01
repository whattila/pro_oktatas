using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_oktatas.product
{
    public record Product
    {
        private int id;
        private string name;
        private string category;
        private int price;

        public required int Id 
        { 
            get { return id; }
            init
            {
                if (value <= 0)
                    throw new ArgumentException("Id is not larger than 0!");
                id = value;
            }
        }
        public required string Name
        { 
            get { return name; }
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name is empty!");
                name = value;
            }
        }
        public required string Category
        { 
            get { return category; }
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Category is empty!");
                category = value;
            }
        }
        public required int Price
        {
            get { return price; }
            init
            {
                if (value <= 0)
                    throw new ArgumentException("Price is not larger than 0!");
                price = value;
            }
        }
    }
}
