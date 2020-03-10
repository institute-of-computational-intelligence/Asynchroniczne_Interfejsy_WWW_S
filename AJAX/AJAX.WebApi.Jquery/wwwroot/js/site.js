//// function returning promise
//function getData() {
//    return new Promise(resolve => {
//        setTimeout(() => {
//            resolve("resolved");
//        }, 2000);
//    });
//}

//function syncCall() {
//    console.log("sync calling");
//    getData().then(result => {
//        console.log(result);
//    });
//}

//async function asyncCall() {
//    console.log("async calling");
//    const result = await getData();
//    console.log(result);
//}


//syncCall();
//asyncCall();




//// AJAX JQUERY call
//$.ajax({
//    type: "POST",
//    traditional: true,
//    data: { sort: sortData, desc: descData, filter: filterData, page: pageData },
//    url: "/Users/Index",
//    headers: {
//        'Authorization': 'Bearer xxxxxxxxxxxxx',
//        'X-CSRF-TOKEN': 'xxxxxxxxxxxxxxxxxxxx',
//        'Content-Type': 'application/json'
//    },
//    success: function (data) {
//        $("#users").html(data);
//    },
//    error: function (jqXHR, textStatus) {
//        alert("błąd: " + textStatus);
//    }
//});


//// post
//$.post("/Post/AddValue", $.param({ value: "new value" }), function (data) {
//    $(".result").html(data);
//    alert("Value was posted");
//});

//// get
//$.get("/Post/GetAll", function (data) {
//    $(".result").html(data);
//});





// DELETE
fetch(`/User/${id}`,
        { method: 'DELETE' })
    .then(res => res.json())
    .then(res => {
        console.log('Deleted:', res.message);
        return res;
    })
    .catch(err => console.error(err));



// POST or PUT
const data = { username: 'example' };
fetch('https://example.com/profile', {
        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
            "Authorization" : "Bearer {token}"
        },
        body: JSON.stringify(data),
    })
    .then((response) => response.json())
    .then((data) => {
        console.log('Success:', data);
    })
    .catch((error) => {
        console.error('Error:', error);
    });




