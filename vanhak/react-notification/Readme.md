Task

This challenge builds on a provided Notification component to add a new Confirmation component. The Confirmation component will extend the functionality of the basic notification by enabling the user to accept or decline an action prompt.

The Confirmation component should render a Notification component as its root element. The notification should be augmented with two additional buttons which enable actions to be taken based on the user's response: accept or decline. These buttons will trigger a corresponding callback function when clicked.

The props passed to Confirmation will look like this:

{
  message: 'Should we bake a pie?',
  type: 'message',
  accept: () => {
    // to be called when the user clicks the "accept" button
  },
  decline: () => {
    // to be called when the user clicks the "decline" button
  }
}

The resulting component markup should look like this:

<div class="alert alert-info">
  <p>Should we bake a pie?</p>
  <button class="btn btn-primary">Yes</button>
  <button class="btn btn-danger">No</button>
</div>

Which, when rendered, appears roughly as follows:

Should we bake a pie?



When either of the accept or decline buttons is clicked, the confirmation should be dismissed and will no longer render.

Note that all tests associated with this challenge are provided to you in Confirmation.test.jsx. Use these tests as the specification to guide your implementation.

If you get stuck, please visit the corresponding documentation page from React regarding Composition vs Inheritance. In particular, the subsection on Specialization might be particularly useful to help elucidate the relationship between the Confirmation and Notification classes in this challenge.
