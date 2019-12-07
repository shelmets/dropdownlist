using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropDownList
{
    public partial class Form1 : Form
    {
        IStream str;
        ILogic logic;
        CancellationTokenSource currCancelTokenSource = new CancellationTokenSource();
        CancellationTokenSource prevCancelTokenSource = null;
        private readonly object balanceLock = new object();
        public Form1(IStream s, ILogic log)
        {
            InitializeComponent();
            str = s;
            logic = log;
        }
        private async void textBoxEnter_TextChanged(object sender, EventArgs e)
        {
            prevCancelTokenSource = currCancelTokenSource;
            currCancelTokenSource = new CancellationTokenSource();
            prevCancelTokenSource.Cancel();
            try
            {
                await AddUniversInListBoxCancellableTaskAsync(textBoxEnter.Text, currCancelTokenSource.Token);
            }
            finally
            {
                ;
            }
        }
        private Task AddUniversInListBoxCancellableTaskAsync(string text, CancellationToken currToken)
        {
            Task task = null;

            task = Task.Run(() => AddUniversInListBox(task, textBoxEnter.Text, currToken));

            return task;
        }
        private void AddUniversInListBox(Task task, string text, CancellationToken currToken)
        {
            if (currToken.IsCancellationRequested)
                return;
            listBoxOutput.Items.Clear();

            if (currToken.IsCancellationRequested)
                return;

            var iteribleStr = logic.GetOptions(str, text, 5);
            if (text.Length != 0)
            {
                if (iteribleStr.Count() != 0)
                {
                    foreach (var i in iteribleStr)
                    {
                        if (currToken.IsCancellationRequested)
                            return;
                        listBoxOutput.Items.Add(i);
                    }
                }
                else
                {
                    if (currToken.IsCancellationRequested)
                        return;
                    listBoxOutput.Items.Add("Not Found");
                }
            }
        }
        private void listBoxOutput_DoubleClick(object sender, EventArgs e)
        {
            foreach(var i in logic.GetInformation(str, listBoxOutput.SelectedItem.ToString()))
            {
                new GetUrl(i.Item1, i.Item2).Show();
            }
        }
        private void listBoxOutput_Enter(object sender, EventArgs e)
        {
            new EnterSyn(((ListBox)sender).SelectedItem.ToString(), str).Show();
        }
    }
}
