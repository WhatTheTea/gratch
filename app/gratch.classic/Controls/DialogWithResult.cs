using System.ComponentModel;

namespace gratch.classic.Controls;
public class DialogWithResult : Form
{
    private TaskCompletionSource<object?> resultTCS = new();

    protected void SetResult(object result, bool shouldClose = true)
    {
        this.resultTCS.TrySetResult(result);

        if (shouldClose)
        {
            this.Close();
        }
    }

    protected void Cancel(bool shouldClose = true)
    {
        this.resultTCS.TrySetResult(default);

        if (shouldClose)
        {
            this.Close();
        }
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        if (this.resultTCS.Task.Status is not TaskStatus.RanToCompletion)
        {
            this.resultTCS.TrySetResult(default);
        }

        base.OnClosing(e);
    }

    public Task<object?> ShowAsync(IWin32Window parent)
    {
        this.ShowDialog(parent);
        return this.resultTCS.Task;
    }
}
