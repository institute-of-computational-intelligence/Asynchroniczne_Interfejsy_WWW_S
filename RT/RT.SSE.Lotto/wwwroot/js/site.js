var source = new EventSource(`/Lotto/StartDrawing`); // `/SSE/SendMessage?message=${msg}` optionally passing arguments to event source action
source.onopen = function (event) {
    // event occured when connection is open
};

source.onmessage = function (event) {
    const lotteryDrawObj = JSON.parse(event.data);
    const lotteryDrawItem = $(`<li><span>draw date: ${lotteryDrawObj.DrawTimestamp}, Numbers: ${lotteryDrawObj.Nr1}, ${lotteryDrawObj.Nr2}, ${lotteryDrawObj.Nr3}, ${lotteryDrawObj.Nr4}, ${lotteryDrawObj.Nr5}, ${lotteryDrawObj.Nr6}</span></li>`);
    $(".lottery-container ul#lucky-numbers").append(lotteryDrawItem);
};

source.onerror = function (event) {
    // event occured when connection is closed
    source.close();
};
