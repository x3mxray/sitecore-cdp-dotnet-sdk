using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCDP.SDK.Models.Batch
{
    /// <summary>
    /// The batch file processing status.
    /// </summary>
    public static  class BatchStatusCode
    {
        /// <summary>
        /// uploading - the import process was initialized by the client.
        /// </summary>
        public static readonly string Uploading = "uploading";
        /// <summary>
        /// processing - import file was uploaded and processing has started.
        /// </summary>
        public static readonly string Processing = "processing";
        /// <summary>
        /// success - import file was successfully processed.
        /// </summary>
        public static readonly string Success = "success";
        /// <summary>
        /// corrupted - import file did not match the checksum.
        /// </summary>
        public static readonly string Corrupted = "corrupted";
        /// <summary>
        /// error - import has failed, see the log file. The location of the log file is the value of the BatchStatus.LogUri parameter.
        /// </summary>
        public static readonly string Error = "error";
    }
}
