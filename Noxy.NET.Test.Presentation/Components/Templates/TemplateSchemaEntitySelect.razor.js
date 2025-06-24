export function Register(refElement, refDotNet, method) {

    new Sortable(refElement, {
        handle: ".handle",
        animation: 150,
        onSort: event => refDotNet.invokeMethodAsync(method, event.oldIndex, event.newIndex)
    });

}