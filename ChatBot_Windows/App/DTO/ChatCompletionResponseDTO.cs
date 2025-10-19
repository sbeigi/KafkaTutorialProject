using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Windows.App.DTO
{
    public class ChatCompletionResponseDTO
    {
        public string model { get; set; }
        public DateTime created_at { get; set; }
        public ChatCompletionResponseMessageDTO message { get; set; }
        public bool done { get; set; }
        public long? total_duration { get; set; }
        public int? load_duration { get; set; }
        public int? prompt_eval_count { get; set; }
        public int? prompt_eval_duration { get; set; }
        public int? eval_count { get; set; }
        public long? eval_duration { get; set; }
    }

    public class ChatCompletionResponseMessageDTO
    {
        public string role { get; set; }
        public string content { get; set; }
    }

}
