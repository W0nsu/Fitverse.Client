function DisplayClasses(calendarClassInFrontendList){
    
    const ColorOptions = ["bg-fitverseDarkPurple", "bg-fitverseLightPurple", "bg-fitversePaleBlue", "bg-fitverseCyan"];
    let ColorCounter = 0;
    let previousDay = -1;
    let ClassesCounter = 0;

    const classContainers = document.getElementsByClassName('classContainer');
    
    calendarClassInFrontendList.forEach((calendarClassInFrontend) => {
        if (previousDay !== calendarClassInFrontend.classDayAsNumber){
            ColorCounter = 0;
        }
        
        const firstIndexOfClass = document.getElementById(calendarClassInFrontend.classStartingTimeId);
        const classParent = firstIndexOfClass.parentElement;

        let classContainer = classContainers.item(ClassesCounter);

        classParent.insertBefore(classContainer, firstIndexOfClass);

        for (let i = 0; i < calendarClassInFrontend.classDurationAsNumberOfIndexes; i++){
            const classPartialElement = document
                .getElementById(calendarClassInFrontend.classDayAsNumber + "-" + (calendarClassInFrontend.classStartingTimeIndex + i));
            classContainer.appendChild(classPartialElement);

            if (i === 0){
                classPartialElement.innerText = calendarClassInFrontend.className;
                classPartialElement.classList.add("text-sm", "text-white", "pt-1");
            }
            if (i === 1){
                classPartialElement.innerText = calendarClassInFrontend.classStartingTime + " - " + calendarClassInFrontend.classEndingTime;
                classPartialElement.classList.add("text-sm", "text-white");
            }

            if (classPartialElement.classList.contains("border-b"))
                classPartialElement.classList.remove("border-b");
            if (classPartialElement.classList.contains("border-gray-700"))
                classPartialElement.classList.remove("border-gray-700");
        }
        
        classContainer.classList.add(ColorOptions[ColorCounter % 4]);
        classContainer.classList.remove("hidden");
        if (ColorCounter % 4 === 3){
            ColorOptions.reverse();
            ColorCounter += 1
        }
        
        previousDay = calendarClassInFrontend.classDayAsNumber;
        ColorCounter += 1;
        ClassesCounter += 1;
    });
}

function DisplayCalendar(){
    const calendar = document.getElementById('calendar');
    while(calendar.firstChild){
        calendar.removeChild(calendar.firstChild);
    }
    
    for (let i = 0; i<=6; i++){
        let border = 0;
        const column = document.createElement('div');
        column.classList.add('flex', 'flex-col', 'bg-fitverseMidGray');
        column.style.width = '12%';
        calendar.appendChild(column);
        for (let j = 0; j <= 71; j++){
            border++;
            if (border === 4 && j !== 71){
                const calendarSubElement = document.createElement('div');
                calendarSubElement.classList.add('h-6', 'w-5/6', 'mx-auto', 'border-b', 'border-gray-700');
                calendarSubElement.id = i + '-' + j;
                column.appendChild(calendarSubElement);
                border = 0;
            }
            else 
            {
                const calendarSubElement = document.createElement('div');
                calendarSubElement.classList.add('h-6', 'w-5/6', 'mx-auto');
                calendarSubElement.id = i + '-' + j;
                column.appendChild(calendarSubElement);
            }
        }
    }
}