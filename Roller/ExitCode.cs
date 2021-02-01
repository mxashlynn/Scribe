namespace Roller
{
    /// <summary>A value indicating success or the nature of the failure.</summary>
    /// <remarks>Returned when the application terminates to indicate results of the process.</remarks>
    /// See Also: https://docs.microsoft.com/en-us/windows/win32/debug/system-error-codes 
    public enum ExitCode
    {
        /// <summary>The operation completed successfully.</summary>
        Success = 0,
        /// <summary>The specified file could not be found.</summary>
        FileNotFound = 1,
        /// <summary>Access or permission was denied.</summary>
        AccessDenied = 5,
        /// <summary>Invalid data was given.</summary>
        InvalidData = 13,
        /// <summary>An error occurred while attempting to write data.</summary>
        WriteFault = 29,
        /// <summary>An error occurred while attempting to read data.</summary>
        ReadFault = 30,
        /// <summary>An unsupported request was made.</summary>
        NotSupported = 50,
        /// <summary>One or more arguments were incorrect.</summary>
        BadArguments = 160,
    }

    /// <summary>
    /// Extensions to the ExitCode enumeration.
    /// </summary>
    public static class ExitCodeExtensions
    {
        /// <summary>
        /// Translates an <see cref="ExitCode"/> into a message suitable for the end user.
        /// </summary>
        /// <param name="inExitCode">The code to translate.</param>
        /// <returns>The user-facing message.</returns>
        public static string ToStatusMessage(this ExitCode inExitCode)
            => inExitCode switch
            {
                ExitCode.Success => "The operation completed successfully.",
                ExitCode.FileNotFound => "The specified file could not be found.",
                ExitCode.AccessDenied => "Access or permission was denied.",
                ExitCode.InvalidData => "Invalid data was given.",
                ExitCode.WriteFault => "An error occurred while attempting to write data.",
                ExitCode.ReadFault => "An error occurred while attempting to read data.",
                ExitCode.NotSupported => "An unsupported request was made.",
                ExitCode.BadArguments => "One or more arguments were incorrect.",
                _ => $"Unknown command result: {inExitCode}",
            };
    }
}
