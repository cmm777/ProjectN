Software to Install:
Visual Studio Code
Git
.Net SDK (I'm using 7.0)

Clone:
Nuvolar repo

Commands to execute:
dotnet build
dotnet test

Following you can find the exercises solved, divided into 4 sections:
1 - Frontend testing manual excercise
2 - Backend testing manual exercise
3 - Frontend testing automation exercise
4 - Backend testing automation exercise

—------------------------------------------------------------------------------------------------------------------------------------------
1 - Frontend testing manual excercise

Assumptions:
• I would write the test cases in a tool such as Azure DevOps which allows me to use the format I choose to write the tests and also allows to have expected results per line of the test case
• Validations are triggered when the focus is moved to a different element (example: from First Name to Last Name triggers First Name validation)
• Validation error messages are generic, if a field has 2 or more validations, the same message will be displayed for all, unless a specific wording is mentioned in the requirements
• All characters are accepted in the First name, Last Name and Password fields
• A single validation message is displayed for missing data into 1 or more of the 3 DOB dropdowns
• There's no limit to introduce past dates into the DOB dropdowns, except the limitations established in the dropdown itself
• Characters accepted for email addresses are industry standard, no validations will be done there
• Terms and conditions element looks like a radio button, not a checkbox. It will be treated like a checkbox as described in the requirements
• I assume Terms and conditions are displayed in a modal, there is no navigation triggered on click
• Each one of the 7 required field should have a test case validating that the field is not filled when clicking the "Register" button, if all 6 others are filled with valid data and the one under testing is left blank/unchecked (This includes leaving blank one of the three dropdowns for the birth date). I created a single test case that covers all at the same time, just for time saving purposes, and for all others I just added the title, but the logic is the same for all. Applies for tests 30 to 38
• I will assume that login in with an inactive account is not possible, but since I don't know which flow is implemented for such case, I will not create any extra validations
• For test 41 I assume the browser was not closed, the navigation data was not deleted and the session is not expired when using the same browser as the one used for registration
• I assume accounts can be created using emails with an alias. Example:
test@gmail.com != test+1@gmail.com
• I haven't created a full test to validate the message displayed requesting the account activated, just the title
Suggested improvements:
1- There should be a confirm password field
2- Strong password policies should be enforced
3- The way to select the DOB could be changed to a DatePicker component


List of test cases


Test 1
“Verify ‘First Name’ field values accepted”
Steps:
Navigate to page X
Select to create a new account
Introduce a value between 4 and 150 characters in the “First Name” field
Expected result:
There is no validation message displayed

Test 2
“Verify ‘First Name’ field with less than 4 characters”
Steps:
Navigate to page X
Select to create a new account
Introduce a value with less than 4 characters in the “First Name” field
Expected result:
A validation message is displayed stating the value introduced is invalid

Test 3
“Verify ‘First Name’ field with more than 150 characters”
Steps:
Navigate to page X
Select to create a new account
Introduce a value with more than 150 characters in the “First Name” field
Expected result:
A validation message is displayed stating the value introduced is invalid

Test 4
“Verify ‘Last Name’ field values accepted”
Steps:
Navigate to page X
Select to create a new account
Introduce a value between 4 and 150 characters in the “Last Name” field
Expected result:
There is no validation message displayed

Test 5
“Verify ‘Last Name’ field with less than 4 characters”
Steps:
Navigate to page X
Select to create a new account
Introduce a value with less than 4 characters in the “Last Name” field
Expected result:
A validation message is displayed stating the value introduced is invalid

Test 6
“Verify ‘Last Name’ field with more than 150 characters”
Steps:
Navigate to page X
Select to create a new account
Introduce a value with more than 150 characters in the “Last Name” field
Expected result:
A validation message is displayed stating the value introduced is invalid

Test 7
“Verify ‘Date of Birth’ accepted values”
Steps:
Navigate to page X
Select to create a new account
Introduce a valid birth date using the 3 dropdowns for day, month and year
Date introduced should not be in the future
Expected result:
There is no validation message displayed

Test 8
“Verify ‘Date of Birth’ for future dates”
Steps:
Navigate to page X
Select to create a new account
Introduce a valid birth date using the 3 dropdowns for day, month and year
Date introduced should be in the future
Expected result:
There is a validation message displayed stating: "Selected date exceeds the current date."

Test 9
“Verify ‘Date of Birth’ for 29/02 on a leap year”
Steps:
Navigate to page X
Select to create a new account
Introduce the date 29/02/1996 using the 3 dropdowns for day, month and year
Expected result:
There is no validation message displayed

Test 10
“Verify ‘Date of Birth’ for 29/02 not on a leap year”
Steps:
Navigate to page X
Select to create a new account
Introduce the date 29/02/1995 using the 3 dropdowns for day, month and year
Expected result:
There is a validation message displayed stating that the date introduced is invalid

Test 11
“Verify ‘Email’ field accepted values”
Steps:
Navigate to page X
Select to create a new account
Introduce a string in the Email field with the format defined in the following regex: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g (example: test@test.com)
Email should have 150 characters or less
Expected result:
There is no validation message displayed

Test 12
“Verify ‘Email’ field invalid formats”
Steps:
Navigate to page X
Select to create a new account
Introduce a string in the Email field with the format defined in the following regex: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g 
Email should have more than 150 characters
Expected result:
There is an “Invalid Email” validation message displayed for the Email field

Test 14
“Verify ‘Email’ field for invalid formats”
Steps:
Navigate to page X
Select to create a new account
Introduce a string in the Email field with the format defined in the following regex: /^([\w-]+\.)+[\w-]{2,4}$/g (example: test.com)
Email should have 150 characters or less
Expected result:
There is an “Invalid Email” validation message displayed for the Email field

Test 15
“Verify ‘Email’ field for invalid formats”
Steps:
Navigate to page X
Select to create a new account
Introduce a string in the Email field with the format defined in the following regex: /^[\w-\.]+@[\w-]+[\w-]{2,4}$/g (example: test@test)
Email should have 150 characters or less
Expected result:
There is an “Invalid Email” validation message displayed for the Email field

Test 16
“Verify ‘Repeat Email’ field accepted values”
Steps:
Navigate to page X
Select to create a new account
Introduce a string in the Repeat Email field with the format defined in the following regex: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g (example: test@test.com)
Email should have 150 characters or less
Expected result:
There is no validation message displayed

Test 17
“Verify ‘Repeat Email’ field for invalid formats”
Steps:
Navigate to page X
Select to create a new account
Introduce a string in the Repeat Email field with the format defined in the following regex: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g
Email should have more than 150 characters
Expected result:
There is an “Invalid Email” validation message displayed for the Repeat Email field

Test 18
“Verify ‘Repeat Email’ field for invalid formats”
Steps:
Navigate to page X
Select to create a new account
Introduce a string in the Repeat Email field with the format defined in the following regex: /^([\w-]+\.)+[\w-]{2,4}$/g (example: test.com)
Expected result:
There is an “Invalid Email” validation message displayed for the Repeat Email field

Test 19
“Verify ‘Email’ field for invalid formats”
Steps:
Navigate to page X
Select to create a new account
Introduce a string in the Repeat Email field with the format defined in the following regex: /^[\w-\.]+@[\w-]+[\w-]{2,4}$/g (example: test@test)
Expected result:
There is an “Invalid Email” validation message displayed for the Repeat Email field

Test 20
“Verify ‘Email’ validation for matching emails”
Steps:
Navigate to page X
Select to create a new account
Introduce a string in the Email field with the format defined in the following regex: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g (example: test@test.com)
Introduce the same string in the Repeat Email field
Expected result:
There is no validation message displayed

Test 21
“Verify ‘Email’ validation for not matching emails”
Steps:
Navigate to page X
Select to create a new account
Introduce a string in the Email field with the format defined in the following regex: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g (example: test@test.com)
Introduce a different string in the Repeat Email field with the format defined in the following regex: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g (example: 1337@test.com)
Expected result:
There is a validation message displayed stating that the emails should match

Test 23
“Verify ‘Password’ field values accepted”
Steps:
Navigate to page X
Select to create a new account
Introduce a value between 6 and 20 characters in the “Password” field
Expected result:
There is no validation message displayed

Test 24
“Verify ‘Password’ field with less than 6 characters”
Steps:
Navigate to page X
Select to create a new account
Introduce a value with less than 6 characters in the “Password” field
Expected result:
A validation message is displayed stating the value introduced is invalid

Test 25
“Verify ‘Password’ field with more than 20 characters”
Steps:
Navigate to page X
Select to create a new account
Introduce a value with more than 20 characters in the “Password” field
Expected result:
A validation message is displayed stating the value introduced is invalid

Test 26
“Verify ‘Terms and Conditions’ checkbox can be checked”
Steps:
Navigate to page X
Select to create a new account
Click the “Terms and Conditions” checkbox
Expected result:
The box is checked

Test 27
“Verify ‘Terms and Conditions’ checkbox can be unchecked”
Steps:
Navigate to page X
Select to create a new account
Click the “Terms and Conditions” checkbox to get it checked
Click the “Terms and Conditions” checkbox again
Expected result:
The box is unchecked

Test 28
“Verify ‘Terms and Conditions’ are displayed when the link is clicked”
Steps:
Navigate to page X
Select to create a new account
Click the “Terms and Conditions” link
Expected result:
The Terms and Conditions are displayed

Test 29
“Verify mandatory fields for account registration”
Steps:
Navigate to page X
Select to create a new account
Observe the mandatory fields marked with an *
Expected result:
The mandatory fields are:
First Name
Last Name
Date of Birth, which requires:
Date of Birth day (dropdown)
Date of Birth month (dropdown)
Date of Birth year (dropdown)
Email
Repeat Email
Password
Terms and conditions (checkbox)

Test 30
“Verify missing fields validations”
Steps:
Navigate to page X
Select to create a new account
Do not fill any fields, or dropdowns
Do not check the Terms and conditions checkbox
Click the “Register” button
Expected result:
The account is not registered
Each one of the 7 required fields described in Test 29: “Verify mandatory fields for account registration” displays a validation with the format: "Please fill in this <<FIELD>>"

Test 30
“Verify missing “First Name” validation”

Test 31
“Verify missing “Last Name” validation”

Test 32
“Verify missing “DOB day” validation”

Test 33
“Verify missing “DOB month” validation”

Test 34
“Verify missing “DOB Year” validation”

Test 35
“Verify missing “Email” validation”

Test 36
“Verify missing “Repeat Email” validation”

Test 37
“Verify missing “Password” validation”

Test 38
“Verify unchecked “Terms and Conditions” validation”

Test 39
“Verify the successful account registration”
Steps:
Navigate to page X
Select to create a new account
Fill all of the mandatory fields marked with an * with valid data
Use an email not associated with an active account
Check the “Terms and Conditions” box
Click the “Register” button
Expected result:
The account is registered
The user is redirected to a page with a message stating that the account should be activated
The user receives an email for the account associated address containing information and a link to activate the account (check the spam folder also)

Test 40
“Verify the user cant login with an account not activated”
Steps:
Navigate to page X
Select to create a new account
Fill all of the mandatory fields marked with an * with valid data
Use an email not associated with an active account
Check the “Terms and Conditions” box
Click the “Register” button
Without activating the account, attempt to log in using the newly created credentials (email and password)
Expected result:
User is not logged in

Test 41
“Verify the account activation in the same browser”
Steps:
Navigate to page X
Select to create a new account
Fill all of the mandatory fields marked with an * with valid data
Use an email not associated with an active account
Check the “Terms and Conditions” box
Click the “Register” button
Open the activation email received and copy the activation link
Paste it in the same browser the registration took place 
Expected result:
Account is active
The user is logged in after completing the account activation

Test 42
“Verify the account activation in a different browser”
Steps:
Navigate to page X
Select to create a new account
Fill all of the mandatory fields marked with an * with valid data
Use an email not associated with an active account
Check the “Terms and Conditions” box
Click the “Register” button
Open the activation email received and copy the activation link
Paste it in a different browser than the one used to register
Expected result:
Account is active
The user is requested to log in after activating the account

Test 43
“Verify it is not possible to create an account with an already registered email”
Steps:
Navigate to page X
Select to create a new account
Fill all of the mandatory fields marked with an * with valid data
Use an email not associated with an active account
Check the “Terms and Conditions” box
Click the “Register” button
Activate the account
Log out if necessary
Select to create a new account
Fill all of the mandatory fields marked with an * with valid data
Use the same email as in step D for “Email” and “Repeat Email” fields
Check the “Terms and Conditions” box
Click the “Register” button
Expected result:
Account is not registered
The user is redirected to the login page
A message is displayed stating: "There is an existing account associated with <<EMAIL_ADDRESS>>”.

Test 44
“Verify the message displayed requesting the account activation”

—------------------------------------------------------------------------------------------------------------------------------------------
2 - Backend testing manual exercise

Postman collection attached to the email and added to this repository
Considerations:
• Image file needs to be replaced for the test "UploadValidImage" to run successfully
• I wasn't able to get all of the mentioned response codes for invalid inputs, but all of the test cases are prepared to be running with a small modification
• Images uploaded and linked to an existing pet are not displayed as part of the entity when searching a pet by Id or by status
• Some responses dislpay the stack trace, something that is not recommended. Example, the test displays the following stack trace if no file is selected:
{
    "code": 415,
    "type": "unknown",
    "message": "com.sun.jersey.api.MessageException: A message body reader for Java class com.sun.jersey.multipart.FormDataMultiPart, and Java type class com.sun.jersey.multipart.FormDataMultiPart, and MIME media type application/octet-stream was not found.\nThe registered message body readers compatible with the MIME media type are:\n*/* ->\n  com.sun.jersey.core.impl.provider.entity.FormProvider\n  com.sun.jersey.core.impl.provider.entity.StringProvider\n  com.sun.jersey.core.impl.provider.entity.ByteArrayProvider\n  com.sun.jersey.core.impl.provider.entity.FileProvider\n  com.sun.jersey.core.impl.provider.entity.InputStreamProvider\n  com.sun.jersey.core.impl.provider.entity.DataSourceProvider\n  com.sun.jersey.core.impl.provider.entity.XMLJAXBElementProvider$General\n  com.sun.jersey.core.impl.provider.entity.ReaderProvider\n  com.sun.jersey.core.impl.provider.entity.DocumentProvider\n  com.sun.jersey.core.impl.provider.entity.SourceProvider$StreamSourceReader\n  com.sun.jersey.core.impl.provider.entity.SourceProvider$SAXSourceReader\n  com.sun.jersey.core.impl.provider.entity.SourceProvider$DOMSourceReader\n  com.sun.jersey.json.impl.provider.entity.JSONJAXBElementProvider$General\n  com.sun.jersey.json.impl.provider.entity.JSONArrayProvider$General\n  com.sun.jersey.json.impl.provider.entity.JSONObjectProvider$General\n  com.fasterxml.jackson.jaxrs.json.JacksonJsonProvider\n  com.sun.jersey.core.impl.provider.entity.XMLRootElementProvider$General\n  com.sun.jersey.core.impl.provider.entity.XMLListElementProvider$General\n  com.sun.jersey.core.impl.provider.entity.XMLRootObjectProvider$General\n  com.sun.jersey.core.impl.provider.entity.EntityHolderReader\n  com.sun.jersey.json.impl.provider.entity.JSONRootElementProvider$General\n  com.sun.jersey.json.impl.provider.entity.JSONListElementProvider$General\n  com.sun.jersey.json.impl.provider.entity.JacksonProviderProxy\napplication/octet-stream ->\n  com.sun.jersey.core.impl.provider.entity.ByteArrayProvider\n  com.sun.jersey.core.impl.provider.entity.FileProvider\n  com.sun.jersey.core.impl.provider.entity.InputStreamProvider\n  com.sun.jersey.core.impl.provider.entity.DataSourceProvider\n  com.sun.jersey.core.impl.provider.entity.RenderedImageProvider\n"
}
This should be changed to a generic message that doesn't mention the site architecture
Execution:
There are a total of 55 test cases and there are 12 test that fail when the whole collection runs
UploadValidImage fails only during the collection run, standalone passes, need to investigate which configuration is affecting it
UploadInvalidImage fails because the expected code is not returned, 415 is returned instead
CreatePetInvalid returns a 200 instead of a 405 because I couldn’t find an invalid value that returns that code
UpdatePetInvalidId (json), UpdatePetInvalidUnexisting (json) and UpdatePetInvalidValidation (json), all fails because the record is created without checking (or directly ignoring) if a record with the same Id exists, if the Id is valid or if there is a validation issue
GetPetsAllStatus fails because even if Swagger mentions it is possible to select multiple statuses, only the first one introduced return results. This can be verified by switching the parameters position and triggering the request again
GetPetsInvalidStatus returns a 200 code for a request asking for a status not listed in the enums list, that should be validated. At the same time, the record creation does not validate if the status is provided, or if it is in the list of enums, that way it is possible to create records with invalid or empty status
For NotExistingId (form) I wasn’t able to find an invalid Id to trigger the request, so I introduced characters (not accepted format) and obtained a stack trace. All of the elements that are supposed to receive an integer display the same kind of message if the received data is not in the expected format. This messages should be changed to something generic
For UpdatePetInvalidId (form) I wasn’t able to find an invalid value that triggers the required code
For DeletePetInvalid I wasn’t able to find an invalid value that triggers the required code

The collection includes an end-to-end folder that tests the full flow, there are 8 requests and 25 test cases associated
Validate the record does not exist by generating a random ID and deleting the record associated to it, at this step a variable is generated to hit the same record throughout the test
Create a new record providing several different parameters
Verify the record was created successfully searching by ID
Modify the record using the Put method, changing tags
Modify the record using the Get method, changing the availability
Search the record by status
Delete the record
Validate the record was deleted successfully

—------------------------------------------------------------------------------------------------------------------------------------------
3 - Frontend testing automation exercise

There is a single test case that goes through all of the steps described and makes all of the required validations
It is a simple testing framework developed using the page object model design pattern that I reused from an old projec I have in my GitHub. I update it to have all the functionality covered, both frontend and backend testing. I implemented NUnit for the frontend and added RestSharp for the backend
The site under testing changed from amazon.com to amazon.es because amazon.com has a captcha verification that needs to be bypassed manually and amazon.es only has a cookie modal which can be dismissed, the functionality remains the same
Modified the search conditions, some of the hats returned were unisex, making the test to add the same item in different quantities each time and breaking the validations
Assertions were made all at the end of the interaction with the browser
Ideally I would have created 5 test cases:
- Two test cases for the 2 different options of removing items from the cart: clicking the delete button; or set the quantity to 0
- One test case that unchecks the product card, that doesn’t remove the product but makes the product not be part of the subtotal calculation
- Two test cases for increasing and decreasing quantity, validating the subtotal price is proportionally increased and decreased as the product quantities change
I haven’t implemented this solution because I tried and encountered some technical problems I wasn’t able to solve at the time of removing an element from the cart, and also, the complexity of this solution escapes a little bit the exercise requirements
—------------------------------------------------------------------------------------------------------------------------------------------
4 - Backend testing automation exercise

Using RestSharp I developed 8 different test cases with the required assertions to test the pet store endpoints
This could be done also implementing Newman in the CI/CD implementation, which would allow the team to use the same postman collection for both instances, reducing the number of test suites that requires maintenance
This test cases cover the following:
-Deleting a record that may or may not exist, considering both options
-Create a new record providing several different parameters
-Verify the record was created successfully searching by ID
-Modify the record using the Put method, changing tags
-Modify the record using the Get method, changing the availability
-Search the record by status
-Delete the record
-Validate the record was deleted successfully
