using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine.Networking;

public static class UnityWebRequestAwaiter
{
    public static TaskAwaiter<UnityWebRequestAsyncOperation> GetAwaiter(this UnityWebRequestAsyncOperation asyncOp)
    {
        var tcs = new TaskCompletionSource<UnityWebRequestAsyncOperation>();
        asyncOp.completed += _ => tcs.SetResult(asyncOp);
        return tcs.Task.GetAwaiter();
    }
}