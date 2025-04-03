namespace PlaywrightDemo.src.main.common;

using System;
using System.IO;

public static class EnvVar
{
    public static void Load(string filePath)
    {
        if (!File.Exists(filePath)) return;
        
        foreach (
            var parts in from line in File.ReadAllLines(filePath)
            let parts = line.Split(
                '=',
                StringSplitOptions.RemoveEmptyEntries
            )
            select parts
        )
    
        {
            if (parts.Length != 2) continue;
        
            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
    }
}