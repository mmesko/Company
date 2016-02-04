using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Common
{
    /// <summary>
    /// Class that provides filtering options
    /// </summary>
    public class GenericPaging
    {
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        public GenericPaging(int pageNumber, int pageSize)
        {
            defaultPageSize = 20;
            this.pageSize = pageSize;
            this.pageNumber = pageNumber;
        }

  

        protected int pageNumber;
        protected int pageSize;
        protected int defaultPageSize;

        /// <summary>
        /// Gets page number
        /// </summary>
        public virtual int PageNumber
        {
            get
            {
                if (pageNumber <= 0)
                    pageNumber = 1;

                return pageNumber;
            }
        }

        /// <summary>
        /// Gets page size
        /// </summary>
        public virtual int PageSize
        {
            get
            {
                if (pageSize <= 0 || pageSize > defaultPageSize)
                    pageSize = defaultPageSize;
                return pageSize;
            }
        }

       
    }
}