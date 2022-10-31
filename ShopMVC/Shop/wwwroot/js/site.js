// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

class Hello extends React.Component {
    render() {
        return <h1>Привет, React.JS</h1>;
    }
}
ReactDOM.render(
    <Hello />,
    document.getElementById("content")
);
