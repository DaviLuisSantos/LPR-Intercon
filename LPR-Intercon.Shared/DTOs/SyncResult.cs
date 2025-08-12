using System;
using System.Collections.Generic;
using System.Text;

namespace LPR_Intercon.Shared.DTOs;

public class SyncResult
{
    public int ReceivedCount { get; set; }
    public int SqliteSavedCount { get; set; }
    public int FirebirdSavedCount { get; set; }
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}
