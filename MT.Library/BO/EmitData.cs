using MT.Library;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MT.Library
{
    /// <summary>
    /// Đối tượng dùng để bắn thông báo
    /// </summary>
    public class EmitData
    {
        public string EventName { get; set; }

        public string Uid { get; set; }
        public string Data { get; set; }
    }
}
