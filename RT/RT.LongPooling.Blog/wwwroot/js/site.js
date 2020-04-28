function showPost(postStr) {
    let posts = JSON.parse(postStr);
    let postList = $("#posts");
    postList.empty();
    posts.forEach(function(post, i) {
    let li = $(`<li><span>Title: ${post.title} </span><span> Text: ${post.text}</span></li>`);
        postList.append(li);
    });
}

async function subscribe() {
    let response = await fetch("/Blog/Subscribe");

    if (response.status === 502) {
        // Connection timeout
        // happens when the connection was pending for too long, let's reconnect
        await subscribe();
    } else if (response.status !== 200) {
        // Show Error
        showPost(response.statusText);
        // Reconnect in one second
        await new Promise(resolve => setTimeout(resolve, 1000));
        await subscribe();
    } else {
        // Got message
        let post = await response.text();
        showPost(post);
        await subscribe();
    }
}

$("#add-post-form .add-post-btn").click(async function (event) {
    event.preventDefault();
    let postData = {
        title: $("#add-post-form #Title").val(),
        text: $("#add-post-form #Text").val()
    }
    await fetch("/Blog/AddPost",
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postData)
        });
});

$(document).ready(function () {
    subscribe();
});
