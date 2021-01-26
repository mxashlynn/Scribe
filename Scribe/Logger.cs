using System;
using System.IO;
using System.Windows.Forms;
using Parquet;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// Logs messages to file and presents them to the user when neccessary.
    /// </summary>
    public sealed class LoggerUI : ILogger, IDisposable
    {
        /// <summary>Used to display low priority messages.</summary>
        private ToolStripStatusLabel InfoStrip;

        /// <summary>Used to log all messages.</summary>
        private StreamWriter LogWriter;

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
        public void Log(LogLevel inLogLevel, string inMessage = null, Exception inException = null)
        {
            var message = !string.IsNullOrEmpty(inMessage)
                ? inMessage
                : inException is not null
                    ? inException.Message
                    : $"Scribe Trace at {DateTime.Now}.";

            LogWritter.WriteLine($"{nameof(Scribe)} {inLogLevel.ToString()} {message}");

            switch (inLogLevel)
            {
                case Debug:
                    break;
                case Info:
                case Warning:
                    InfoStrip.Text = message;
                    break;
                case Error:
                    _ = MessageBox.Show(message,
                                        Resources.CaptionError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case Fatal:
                    _ = MessageBox.Show($"{message}\n{Resources.ErrorFatal}",
                                        Resources.CaptionError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        /// <summary>Disposes of the <see cref="StreamWriter"/>.</summary>
        public void Dispose()
            => LogWriter?.Dispose();
    }
}
