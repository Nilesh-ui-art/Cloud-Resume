window.addEventListener('DOMContentLoaded' , (event) =>{
    getVisitCount();
})

const functionApiUrl = 'https://getcloudresume.azurewebsites.net/api/GetResumeCounter?code=DOLnM51_YfGCr9AVte2rT_4kMMchGTHAs84ZAPaLr5JgAzFuPRFQlQ==';
const localFunctionApi = 'http://localhost:7071/api/GetResumeCounter';

const getVisitCount = () => {
    let count = 10;
    fetch(functionApiUrl).then(response => {
        return response.json()
    }).then(response => {
        console.log("Website Called Function API.");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}