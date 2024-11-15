import React, { useEffect, useState } from 'react';
import './App.css';

interface WeatherForecast {
  date: string;
  temperatureC: string;
  summary: String;
}

function App() {
  
  const [weather, setWeather] = useState<WeatherForecast[]>([{date: "01.11.2021", temperatureC: "12", summary: "worm"}]);
  
  useEffect(() => {
    fetch('https://localhost:7099/weatherforecast')
      .then(response => response.json())
      .then(data => {        
        setWeather(data);
      });
  }, []);

  

  return (
    <div className="App">
      <h1>{"Погода"}</h1>
      <div className='app-table'>
        <table>
        {
          weather.map((item, i) => {
            return <tr key={i}>
              <td>{item.date}</td>
              <td>{item.temperatureC}°C</td>
              <td>{item.summary}</td>
            </tr>
          })
        }
        </table>
      </div>
      
    </div>
  );
}

export default App;
