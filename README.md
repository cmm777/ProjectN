Software to Install:
Visual Studio Code
Git
.Net SDK (I'm using 7.0)

Clone:
FullFabric repo

Commands to execute:
dotnet build
dotnet test

I successfully created a script that goes through the open positions and verifies if there is a QA opportunity listed. I refactored a framework I created last year and adapted it to this challenge, that allowed me to save some time
The challenge description says I could go to the form, but there were no requirements related to that page so I didn't create a test covering it

I would add the following tests to a test plan for the careers section:
The careers page itself doesn't have much to test besides applying for a job, there are 2 different buttons that scroll to the open positions and the "Contact us" that redirects the user to the email. There are no other systems involved for the 3 functionalities mentioned, so, there are 4 tests
1 - Click on Positions Available redirects to https://www.fullfabric.com/company/careers#new-jobs-container
2 - Click on Join Us redirects to https://www.fullfabric.com/company/careers#new-jobs-container
3 - Navigating to https://www.fullfabric.com/company/careers#new-jobs-container takes the user directly to the list of opportunities without going to the page top
4 - Click on contact us displays the email client with the email addres and subject filled
None of those qualifies for a regression/smoke in my opinion

More test cases should be added to validate the application flow:
5 - Clicking an element in the list opens the application form in a new tab (I'm guessing opening it in a new tab is the requirement, it might be not desired. Also, hovering the element in the list highlights the entire box, but only the position title can be clicked, again, not sure if thats by design or not)

In the application form there are several fields, 4 of the mandatory (I can't be sure without actually start playing with the form, but that might cause an application to be sent, so I prefered not to do that)
6 - Validation on the first name field being empty
7 - Validation on the last name field being empty
8 - Validation on the email field being empty
9 - Validation on the email field content (validate the format includes an @ and a .)
10 - Validation on the phone number field being empty
11 - Validation on the phone number field content (invalid number)
12 - Upload a CV (field is not marked as mandatory, I think either CV upload or apply with LinkedIn should be required to proceed, but that's something that should be clarified by the design team)
13 - Validation on the privacy policy agreement
14 - Apply to the position successfully
15 - Use special characters for the first and last name and validate both the frontend and backend validations do not present any issues

Last, and considering I could direcly use the company systems, I would add the following:

On the backend side, it is important to have a test case that validates the endponit that receives the requests from this form is up and running before start sending applications, for that matter, a health check suite of test cases should run against all of the endpoints before starting the actual test suite
The validations performed on the UI should be also done on the backend side to avoid issues. If a request is sent to the endpoint and there are mandatory information missing, the endpoint should return the configured response and not a default error message
Additional test cases can be added to validate the optional fields content do not cause issues when added to to the form/request

It is important to validate the information provided by the applicant in the form is stored correctly in the database, specially if we consider the special characters and also, a field that should allow to easily differentiate the applicants by the position they applied to (Example: "3656312-staff-engineer" or "3648234-senior-quality-assurance-engineer" should be translated to a field in the database so people reviewing the applications have better control)
