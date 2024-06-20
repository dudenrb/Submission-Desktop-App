# Submission-Desktop-App

Certainly! Here's a comprehensive `README.md` file.

## Desktop App Description

### Overview
This is a Windows Desktop Application created using Visual Basic in Visual Studio. The application allows users to create and view form submissions. The submissions include fields for Name, Email, Phone Number, and GitHub repository link, along with a stopwatch functionality.

### Features
- **View Submissions**: Navigate through all form submissions with Previous and Next buttons.
- **Create New Submission**: Fill out a form with Name, Email, Phone Number, GitHub repo link, and stopwatch time. Pause and resume the stopwatch without resetting.
- **Keyboard Shortcuts**: 
  - **Ctrl + S**: Submit the form on the Create New Submission page.

### Requirements
- Windows Operating System
- Visual Studio with Visual Basic

### Installation
1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```

2. Open the project in Visual Studio.

3. Build and run the project.

### Usage
1. **Main Form**: 
   - Click on "View Submissions" to open the View Submissions form.
   - Click on "Create New Submission" to open the Create Submission form.

2. **Create Submission Form**:
   - Fill in the Name, Email, Phone Number, and GitHub repo link.
   - Start and pause the stopwatch using the "Start Stopwatch" button.
   - Submit the form using the "Submit" button or by pressing **Ctrl + S**.

3. **View Submissions Form**:
   - Use the "Previous" and "Next" buttons to navigate through the submissions.

### Code Overview
#### MainForm.vb
Handles the main form with buttons to navigate to "View Submissions" and "Create New Submission" forms.

#### CreateSubmissionForm.vb
Handles the form where new submissions are created and submitted.

#### ViewSubmissionsForm.vb
Handles the form where submissions can be viewed and navigated through.
