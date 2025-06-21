window.cardHub = {
    connection: null,
    start: function (dotNetRef) {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:7009/cardHub")
            .withAutomaticReconnect()
            .build();

        this.connection.on("CardAdded", function (card) {
            dotNetRef.invokeMethodAsync("CardAddedMessage", card);
        });   
        
        this.connection.on("CardDeleted", function (card) {
            dotNetRef.invokeMethodAsync("CardDeletedMessage", card);
        }); 

        this.connection.on("CardUpdated", function (card) {
            dotNetRef.invokeMethodAsync("CardUpdatedMessage", card);
        }); 

        this.connection.start().catch(function (err) {
            console.error("SignalR Connection Error:", err.toString());
        });
    }
};
