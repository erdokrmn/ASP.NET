import FingerprintJS from '@fingerprintjs/fingerprintjs-pro'

// Initialize the agent on application start.
const fpPromise = FingerprintJS.load({
    apiKey: "nHMKRbO5hvOmsHBF27li",
    region: "eu"
})

// Get the visitorId when you need it.
fpPromise
    .then(fp => fp.get())
    .then(result => console.log(result.visitorId))