// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

unlayer.init({
    id: 'editor-container',
    projectId: 1234,
    displayMode: 'email'
});

//var design = {
//    "body": {
//        "values": {
//            "backgroundColor": "#ffffff",
//            "contentAlign": "left",
//            "contentWidth": "850"
//        }
//    }
//};

//unlayer.loadDesign(design);

unlayer.loadBlank({
    backgroundColor: "#ffffff",
    contentAlign: "left",
    contentWidth: "850px",
    fontFamily: {
        label: "Helvetica",
        value: "'Helvetica Neue', Helvetica, Arial, sans-serif"
    }
});

unlayer.addEventListener('design:updated', function (updates) {
    unlayer.exportHtml(function (data) {
        var json = data.design; // design json
        var html = data.html; // design html
        var BlogBody = data.chunks.body;
        $('#unlayer-html').val(BlogBody);
    })
})

function onComplete(response) {
    //alert("Ajax Request Complete");
    console.log(response);
}
function onSuccess(response) {
    toastr.options = {
        positionClass: "toast-bottom-center",
        preventDuplicates: true,
        progressBar: true,
        onHidden: function () {
            window.location.href = '/Blog/Index';
        }
    };
    toastr.success("Blog Post Successful! Redirecting...");
}
function onFailure(xhr, status, error) {
    toastr.options = {
        positionClass: "toast-bottom-center",
        preventDuplicates: true,
        progressBar: true
    };
    toastr.error("An error occurred while posting the blog. Please try again later.");
    console.error(xhr, status, error);
}

function onCompleteNewsletter(data) {
    console.log(data);
}
function onSuccessNewsletter(data, status, xhr) {
    console.log(xhr.status);
    console.log(xhr.responseText);
    toastr.options = {
        positionClass: "toast-bottom-center",
        preventDuplicates: true,
        progressBar: true
    };
    toastr.success("Thank you for subscribing!");
    console.log(data);
}
function onFailureNewsletter(xhr, status, error) {
    console.log(xhr.status);
    console.log(xhr.responseText);
    toastr.options = {
        positionClass: "toast-bottom-center",
        preventDuplicates: true,
        progressBar: true
    };
    if (xhr.status === 409) {
        toastr.warning("You have already subscribed to our newsletter!");
    } else {
        toastr.error("An error occurred while subscribing to our newsletter. Please try again later.");
    }
    console.error(xhr, status, error);
}

//$('#create-button').on('click', function () {
//    unlayer.exportHtml(function (data) {
//        var BlogBody = data.chunks.body;
//        var BlogTitle = $('#title').val();
//        var BlogAuthor = $('#author').val();
//        var BlogCatergory = $('#catergory').val();
//        var BlogShort = $('#short').val();

//        if (BlogTitle != "" && BlogAuthor != "" && BlogCatergory != "" && BlogShort != "") {
//            var uploadFile = $('#img').get(0);
//            var files = uploadFile.files;
//            var BlogImg = null;

//            if (files.length > 0) {
//                BlogImg = files[0];
//            }

//            var formData = new FormData();
//            formData.append("BlogTitle", BlogTitle);
//            formData.append("BlogAuthor", BlogAuthor);
//            formData.append("BlogCatergory", BlogCatergory);
//            formData.append("BlogShort", BlogShort);
//            formData.append("BlogBody", BlogBody);

//            if (BlogImg != null) {
//                formData.append("img", BlogImg, BlogImg.name);
//            }

//            $.ajax({
//                url: '/Blog/CreateBlog',
//                type: 'POST',
//                data: formData,
//                processData: false,
//                contentType: false,
//                success: function (response) {
//                    alert("Blog Posted");
//                    window.location.href = '/Blog/Index';
//                    console.log(response);
//                },
//                error: function (error) {
//                    alert("Blog Post Failed");
//                    console.log(error);
//                }
//            });
//        } else {
//            alert("One or more input fields are empty.");
//        }
//    });
//});



//$('#create-button').on('click', function () {
//    //unlayer.exportHtml({ includeMetaData: false }, function (data) {
//    unlayer.exportHtml(function (data) {
//        //var BlogBody = data.design; // design json
//        //var BlogBody = data.html; // final html
//        var BlogBody = data.chunks.body;

//        var BlogTitle = $('#title').val();
//        //var BlogDate = $('#date').val();
//        var BlogAuthor = $('#author').val();
//        var BlogCatergory = $('#catergory').val();
//        var BlogShort = $('#short').val();
//        var BlogImg = $('#img').val();

//        console.log(BlogTitle, BlogAuthor, BlogCatergory, BlogShort, BlogImg);

//        //var BlogModel = '@Html.Raw(Json.Encode(AustPIC.Models.BlogModel))';
//        //var obj = new BlogModel(title, date, author, catergory, short, img);

//        //function BlogModel(BlogTitle, BlogAuthor, BlogCatergory, BlogShort, BlogBody, BlogImg, BlogView, BlogId, BlogDate) {
//        //    this.BlogId = BlogId;
//        //    this.BlogTitle = BlogTitle;
//        //    this.BlogDate = BlogDate;
//        //    this.BlogAuthor = BlogAuthor;
//        //    this.BlogCatergory = BlogCatergory;
//        //    this.BlogShort = BlogShort;
//        //    this.BlogImg = BlogImg;
//        //    this.BlogBody = BlogBody;
//        //    this.BlogView = BlogView;
//        //}

//        if (BlogTitle != "" && BlogAuthor != "" && BlogCatergory != "" && BlogShort != "") {
//            const blog = new BlogModel(BlogTitle, BlogAuthor, BlogCatergory, BlogShort, BlogBody, BlogImg);

//                $.ajax({
//                    url: '/Blog/CreateBlog',
//                    type: 'POST',
//                    data: {
//                        BlogTitle: BlogTitle,
//                        BlogAuthor: BlogAuthor,
//                        BlogCatergory: BlogCatergory,
//                        BlogShort: BlogShort,
//                        BlogBody: BlogBody,
//                        BlogImg: BlogImg
//                    },
//                    success: function (response) {
//                        alert("Blog Posted");
//                        window.location.href = '/Blog/Index';
//                        console.log(response);
//                    },
//                    error: function (error) {
//                        alert("Blog Post Failed");
//                        console.log(error);
//                    }
//                });
//            };
//        } else {
//            alert("One or more input fields are empty.");
//        }

//    });
//});



//function loadNavBarView(viewName) {
//    $.ajax({
//        url: viewName,
//        type: 'GET',
//        success: function (data) {
//            $('#NavbarContainer').html(data);
//        },
//        error: function (xhr, textStatus, errorThrown) {
//            console.log('Error loading nav bar view: ' + textStatus + ' ' + errorThrown);
//        }
//    });
//}