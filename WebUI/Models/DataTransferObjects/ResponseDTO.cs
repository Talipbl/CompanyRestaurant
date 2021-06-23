using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebUI.Models.DataTransferObjects
{
    public class ResponseDTO<TEntity>
    {
        public ResponseDTO()
        {
            ResponseMessage = new HttpResponseMessage();
        }
        public HttpResponseMessage ResponseMessage { get; set; }
        public TEntity Entity { get; set; }
    }
}
