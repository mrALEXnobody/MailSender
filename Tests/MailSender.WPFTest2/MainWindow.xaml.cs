using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.WPFTest2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private CancellationTokenSource _ProcessCancellation;

        private async void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            var cts = new CancellationTokenSource();

            Interlocked.Exchange(ref _ProcessCancellation, cts)?.Cancel();

            var cancel = cts.Token;

            var file_dialog = new OpenFileDialog
            {
                Title = "Файл данных",
                Filter = "zip-архтвы (*.zip)|*.zip|Все файлы(*.*)|*.*",
                InitialDirectory = Environment.CurrentDirectory
            };

            if (file_dialog.ShowDialog() != true) return;

            var data_file_name = file_dialog.FileName;
            if (!File.Exists(data_file_name)) return;

            var tasks = new List<Task<int>>();
            int[] result;

            IProgress<double> progress = new Progress<double>(p => ProgressInformer.Value = p * 100);

            try
            {
                using (var zip = new ZipArchive(file_dialog.OpenFile()))
                {
                    //var total_length = zip.Entries.Sum(ee => ee.Length);

                    foreach (var zip_entry in zip.Entries.Where(ee => ee.Name.EndsWith(".txt")))
                        tasks.Add(GetWordsCountAsync(zip_entry.Open(), zip_entry.Length, progress, cancel));

                    result = await Task.WhenAll(tasks).ConfigureAwait(true);
                }

                ResultText.Text = $"Количество слов = {result.Sum()}";
            }
            catch (OperationCanceledException)
            {
                ResultText.Text = "Операция отменена";
            }
        }

        private static async Task<int> GetWordsCountAsync(Stream stream, long Length, IProgress<double> Progress, CancellationToken Cancel)
        {
            var reader = new StreamReader(stream);
            var words_count = 0;
            var separators = new[] { ' ' };
            var position = 0l;
            while (!reader.EndOfStream)
            {
                Cancel.ThrowIfCancellationRequested();

                var line = await reader.ReadLineAsync().ConfigureAwait(true);
                position += line.Length;

                await Task.Delay(150, Cancel).ConfigureAwait(true);

                if (string.IsNullOrWhiteSpace(line)) continue;
                words_count += line
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                    .Length;

                Progress?.Report((double)position / Length);
            }

            return words_count;
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            _ProcessCancellation?.Cancel();
        }
    }
}
