using System;

namespace Cosmetic.Core.Response
{
    public class CosApiResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public bool IsTranslated { get; set; }

        public CosApiResponseBase Data { get; set; }

        public object RawData { get; set; }

        public CosApiResponse()
        {
            Success = false;
            IsTranslated = false;
            Data = new CosApiResponseBase();
        }
    }

    public class CosApiResponseBase
    {
        public string Description { get; set; }
        public string ID { get; set; }
    }

}
