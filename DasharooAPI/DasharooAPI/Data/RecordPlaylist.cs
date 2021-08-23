using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Data
{
    public class RecordPlaylist
    {
        public int RecordId { get; set; }
        public Record Record { get; set; }

        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}
