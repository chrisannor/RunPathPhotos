
# Chris Annor - RunPathPhotos API

## Intro
Thank you for taking the time to complete our technical test.  

It consists of one development task that takes an average of about an hour, but there is no formal time limit. We are more interested in seeing a well thought through and complete solution. 

- The task should be completed with an appropriate level of unit testing. 
- Your code should trend towards being SOLID.  
- Your code should compile and run in one step.  
- Your solution should be written in C#, using .NET Full Framework or .NET core 
-  Your solution may use MSTest, NUnit or XUnit  
- You may use additional frameworks/libraries/packages as needed.  

To avoid bounced emails we would like you to submit your results by uploading the relevant ZIP file to a GitHub repository or One Drive folder and share the link with either your agent or the Runpath member of staff who assigned you the test. 
Please avoid including artefacts from your local build (such as NuGet packages or the bin folder(s)) in your final ZIP file.  
Task  Create a Web API that when called:  
- Calls, combines and returns the results of: 
	-  http://jsonplaceholder.typicode.com/photos 
	-  http://jsonplaceholder.typicode.com/albums 
- Allows an integrator to filter on the user id – so just returns the albums and photos relevant to a single user. 

## Getting Started

The application is built as a Web API and I have configured SwaggerUI for easy testing of the endpoint.

There is only one endpoint with details below: 

`[Get]/runpath/RunPath`

Input
Optional `int userId` - for filtering albums by User Id

Output
`{  "success":  true,  "response":  [  {  "photos":  [  {  "albumId":  0,  "id":  0,  "title":  "string",  "url":  "string",  "thumbnailUrl":  "string"  }  ],  "userId":  0,  "id":  0,  "title":  "string"  }  ],  "errorMessage":  "string"  }`



## Running the tests

Test are included in the `RunPathTests` project

The following unit tests are passing:

- [x] call_both_http_methods_to_get_photos_and_albums
- [x] return_all_photos_and_albums_when_no_id_is_entered
- [x] return_only_photos_for_given_user_id
- [x] correctly_insert_photos_into_correct_album_using_album_id