using System;
using System.Collections.Generic;

namespace HelloWorld.Models
{
    public partial class Groups
    {
        public int Id { get; set; }
        public long TelegramId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
