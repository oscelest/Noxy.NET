namespace Noxy.NET.UI.Interfaces;

public interface IWebFormContext<TValue> : IWebFormContext
{
    TValue Model { get; }

    delegate void SubmitFunc(TValue value);
    delegate Task SubmitFuncAsync(TValue value);
    delegate TResult SubmitFunc<out TResult>(TValue value);
    delegate Task<TResult> SubmitFuncAsync<TResult>(TValue value);

    void Submit(SubmitFunc func);
    Task SubmitAsync(SubmitFuncAsync func);
    TResult SubmitWithResult<TResult>(SubmitFunc<TResult> func);
    Task<TResult> SubmitWithResultAsync<TResult>(SubmitFuncAsync<TResult> func);
}

public interface IWebFormContext : IWebFormInputContext
{
    bool IsSubmitting { get; }
    bool HasError { get; }

    delegate void SubmitAction();
    delegate Task SubmitActionAsync();
    delegate TResult SubmitAction<out TResult>();
    delegate Task<TResult> SubmitActionAsync<TResult>();
    delegate void WebFormContextEventHandler(IWebFormContext sender);

    event WebFormContextEventHandler? ContextChanged;
    event WebFormContextEventHandler? ContextValidated;

    bool GetFormHasChanged();
    string[] GetFormErrorList();
    string[] GetFieldErrorList();
    void Clear();
    void Reset();
    bool Validate();
    void WriteError(string message);

    void Submit(SubmitAction func);
    Task SubmitAsync(SubmitActionAsync func);
    TResult SubmitWithResult<TResult>(SubmitAction<TResult> func);
    Task<TResult> SubmitWithResultAsync<TResult>(SubmitActionAsync<TResult> func);

    void HandleException(Exception exception);
    void HandleException(string message, Dictionary<string, IEnumerable<string>>? data = null);
}
