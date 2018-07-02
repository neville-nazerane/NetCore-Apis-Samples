# NetCore-Apis-Samples
Sample projects using NetCore.Apis nugets


## Basic usage of nugets

### Consuming an API

 1. Set up an `ApiConsumer` (with package `NetCore.Apis.Consumer`) object and provide the base URL
 ```
  var consumer = new ApiConsumer("http://myApiUrl");
 ```
  2 Create a basic HTTP request with get, post, put or delete. Let's say the post returns an object of a class "User":
  ```
   var response = consumer.PostAsync<User>("api/myurl", obj); // generic type is optional. 
  ```
  3. The `response` object can be used to check the following
  ```
   HttpStatusCode statusCode = response.StatusCode;
   string text = response.TextResponse; // response also has an implicit operator to string
   HttpResponseMessage msg = response.Response;
   if (response.IsBadRequest) Dictionary<string, string[]> errors = response.Errors; // default format provided by .net core API
   if (response.IsSuccessful) User user = response; // or response.Data
  ```
 ### Using `ModelHandler` on xamarin.forms
 The following uses `NetCore.Apis.XamarinForms`
  1. A `ModelHandler` would map xamarin common components to a class. Let's say you need to map your components to an object of a class "TaskItem". The following lets you create a strongly typed bind between the the two. 
  ```
   var handler = new ModelHandler<TaskItem>()
                .Bind(t => t.Title, title, titleErr)  // title is an Entry
                .Bind(t => t.Priority, priority, priorityErr) // priority is an Entry
                .Bind(t => t.StartTime, startDate, startTime) // startDate and startTime are DatePicker and TimePicker respectively
                .Bind(t => t.EndTime, endDate, endTime) // endDate and endTime are DatePicker and TimePicker respectively
                .Bind(t => t.Completed, completed); // completed is a Switch
  ```
   In the above code, `titleErr` and `priorityErr` are StackLayouts (optional parameters) that would contain any errors from requests submitted. 
   2. Submit a request `SubmitAsync`:
   ```
    await handler.SubmitAsync(
      async t => await Consumer.PostAsync($"api/TaskItems/", t)
   );
   ```
   This function first validates the fields where possible in the client. If this validation fails, it never calls the lamda function (the parameter). The errors are then printed on the mapped StackLayouts mentioned above. If the client validation succeeds, the lamda is called and the response is processed. If the response fails with a 400 error, and model validation errors sent from the server is processed (the response must be in the standard format returned by .net core when `BadRequest(ModelState)` is returned). The errors recieved are displayed against the mapped StackLayouts. 
   
### Setting up your own `ModelHandler` bindings
You can create your own custom bindings between the any data type and components of your choice by using the `IComponentMapper<T>` interface found in the `NetCore.Apis.Client.UI` nuget. Once this class is created, you can set up an extension function for `ModelHandler` to simplify the usage. Examples for these can be found in this [ModelHandlerExtensions class](https://github.com/neville-nazerane/NetCore-Apis/blob/master/NetCore.Apis.XamarinForms/Extensions/ModelHandlerExtensions.cs). This class uses classes created here: [Mappings](https://github.com/neville-nazerane/NetCore-Apis/tree/master/NetCore.Apis.XamarinForms/Mapping). 

   
   
