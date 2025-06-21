// noinspection JSUnusedGlobalSymbols
export class NoxyNETUI {
    static KeyDownPreventDefaultForKeyList(element, list) {
        element.addEventListener("keydown", e => {
            if (list.includes(e.key)) {
                e.preventDefault();
            }
        });
    }

    static EventPreventDefaultForElementEvent(element, event) {
        element.addEventListener(event, e => e.preventDefault());
    }

    static EventStopPropagationForElementEvent(element, event) {
        element.addEventListener(event, e => e.stopPropagation());
    }

    static RegisterCollapsible(refElement, refDotNet, method) {
        const handler = event => {
            console.log("Finished with", event.propertyName);
            if (event.propertyName !== "grid-template-rows") return;
            refDotNet.invokeMethodAsync(method, refElement.getAttribute("state") === "1");
        };

        refElement["__handlerCollapsible"] = handler;
        refElement.addEventListener('transitionend', handler);
    }

    static DeregisterCollapsible(refElement) {
        const handler = refElement["__handlerCollapsible"];

        if (handler) {
            refElement.removeEventListener('transitionend', handler);
            delete refElement["__handlerCollapsible"];
        }
    }

    static AnimateExpand(refElement) {
        console.log("Expanding", refElement);
        refElement.style.marginTop = '';
        refElement.style.gridTemplateRows = 'minmax(0, 1fr)';
        refElement.setAttribute("state", 0);
    }

    static AnimateCollapse(refElement) {
        console.log("Collapsing", refElement);
        refElement.style.marginTop = "0px";
        refElement.style.gridTemplateRows = 'minmax(0, 0fr)';
        refElement.setAttribute("state", 1);
    }

    static SetTheme(theme) {
        window.document.documentElement.setAttribute("theme", theme);
        localStorage.theme = theme;
    }

    static GetTheme() {
        let value = window.document.documentElement.getAttribute("theme") || localStorage.theme;
        if (!value) {
            if (window.matchMedia && window.matchMedia("(prefers-color-scheme: dark)").matches) {
                value = "Dark";
            } else if (window.matchMedia && window.matchMedia("(prefers-color-scheme: light)").matches) {
                value = "Light";
            }
        }
        return value;
    }

    static DropdownCollection = {};

    static RegisterDropdown(id, ref, callback) {
        const element = document.getElementById(id);
        this.DropdownCollection[id] = {id, ref, element};
    }

    static DisposeDropdown(id) {
        delete this.DropdownCollection[id];
    }
}
