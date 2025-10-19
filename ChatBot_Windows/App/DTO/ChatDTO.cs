using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Windows.App.DTO
{
    internal class ChatDTO
    {
        public Guid ChatId { get; set; }
        public string ChatName { get; set; }
        public List<ChatCompletionResponseMessageDTO> ChatMemory {  get; set; }
    }
}
