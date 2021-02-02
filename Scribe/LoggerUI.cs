using System;
using System.IO;
using System.Windows.Forms;
using Parquet;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// Logs messages to file and presents them to the user when necessary.
    /// </summary>
    public sealed class LoggerUI : ILogger, IDisposable
    {
        /// <summary>Used to display low priority messages.</summary>
        private readonly ToolStripStatusLabel InfoStrip;

        /// <summary>Used to log all messages.</summary>
        private readonly StreamWriter LogWriter;

        /// <summary>
        /// Instantiates a new <see cref="LoggerUI"/>.
        /// </summary>
        /// <param name="inFileWriter">Used to write logs to permanent storage.</param>
        /// <param name="inInfoStrip">Used to display logs to the user.</param>
        public LoggerUI(StreamWriter inFileWriter, ToolStripStatusLabel inInfoStrip)
        {
            if (inFileWriter is null
                || inInfoStrip is null)
            {
                _ = MessageBox.Show($"{Resources.ErrorNullLogger}\n{Resources.ErrorFatal}",
                                    Resources.CaptionError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InfoStrip = inInfoStrip;
            LogWriter = inFileWriter;
        }

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <param name="inLogLevel">The severity of the event being logged.</param>
        /// <param name="inMessage">A message summarizing the event being logged.</param>
        /// <param name="inException">The exception related to this event, if any.</param>
        /// <param name="inThrow">If <c>true</c> the given exception will be thrown after logging.</param>
        public void Log(LogLevel inLogLevel, string inMessage = null, Exception inException = null, bool inThrow = false)
        {
            var message = !string.IsNullOrEmpty(inMessage)
                ? inMessage
                : inException is not null
                    ? inException.Message
                    : $"Scribe Trace at {DateTime.Now}.";

            LogWriter.WriteLine($"{nameof(Scribe)} {inLogLevel} {message}");

            switch (inLogLevel)
            {
                case LogLevel.Debug:
                    break;
                case LogLevel.Info:
                case LogLevel.Warning:
                    InfoStrip.Text = message;
                    break;
                case LogLevel.Error:
                    _ = MessageBox.Show(message,
                                        Resources.CaptionError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case LogLevel.Fatal:
                    _ = MessageBox.Show($"{message}\n{Resources.ErrorFatal}",
                                        Resources.CaptionError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (inThrow
                        && inException is not null)
                    {
                        throw inException;
                    }
                    break;
            }
        }

        /// <summary>Disposes of the <see cref="StreamWriter"/>.</summary>
        public void Dispose()
            => LogWriter?.Dispose();
    }
}
