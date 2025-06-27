using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using Microsoft.Win32;
using CsvHelper;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace CodeLineCounterApp
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<FileAnalysisResult> _results = new();
        private AppSettings _settings = new();
        private const string SettingsFile = "settings.json";

        public MainWindow()
        {
            InitializeComponent();
            ResultsGrid.ItemsSource = _results;
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (File.Exists(SettingsFile))
            {
                var json = File.ReadAllText(SettingsFile);
                _settings = JsonSerializer.Deserialize<AppSettings>(json) ?? new();
                ExtensionsBox.Text = string.Join(",", _settings.IncludedExtensions);
                PathsBox.Text = string.Join(",", _settings.ExcludedPaths);
            }
        }

        private void SaveSettings()
        {
            _settings.IncludedExtensions = ExtensionsBox.Text.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(e => e.Trim()).ToList();
            _settings.ExcludedPaths = PathsBox.Text.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
            var json = JsonSerializer.Serialize(_settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SettingsFile, json);
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RootFolderBox.Text = dialog.SelectedPath;
            }
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            _results.Clear();
            SaveSettings();

            if (!Directory.Exists(RootFolderBox.Text))
            {
                MessageBox.Show("Invalid folder path.");
                return;
            }

            var files = Directory.GetFiles(RootFolderBox.Text, "*.*", SearchOption.AllDirectories)
                .Where(file => _settings.IncludedExtensions.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                .Where(file => !_settings.ExcludedPaths.Any(p => file.Contains(p, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            foreach (var file in files)
            {
                int lineCount = File.ReadLines(file).Count();
                _results.Add(new FileAnalysisResult
                {
                    FullPath = file,
                    FileName = Path.GetFileName(file),
                    Extension = Path.GetExtension(file),
                    LineCount = lineCount
                });
            }

            SummaryText.Text = $"Total files: {_results.Count}";
        }

        private void ExportCsvButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "linecount_report.csv"
            };

            if (dialog.ShowDialog() == true)
            {
                using var writer = new StreamWriter(dialog.FileName);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(_results);
                writer.WriteLine($"TOTAL FILES,,,{_results.Count}");
                MessageBox.Show("CSV exported successfully.");
            }
        }
    }

    public class FileAnalysisResult
    {
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int LineCount { get; set; }
    }

    public class AppSettings
    {
        public List<string> IncludedExtensions { get; set; } = new() { ".cs", ".xaml" };
        public List<string> ExcludedPaths { get; set; } = new();
    }
}