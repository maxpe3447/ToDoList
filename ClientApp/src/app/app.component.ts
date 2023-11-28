import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./components/nav/nav.component";
import { HomeComponent } from "./components/home/home.component";
import { AccountService } from './services/accountService';
import { HttpClientModule } from '@angular/common/http';
import { User } from './models/user';
import { ListComponent } from "./components/list/list.component";
import { NgParticlesModule } from "ng-particles";
import { loadSlim } from "tsparticles-slim"; // if you are going to use `loadSlim`, install the "tsparticles-slim" package too.
import { MoveDirection, ClickMode, HoverMode, OutMode, Container, Engine } from "tsparticles-engine";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    providers: [AccountService],
    imports: [HttpClientModule, CommonModule, RouterOutlet, NavComponent, HomeComponent, ListComponent, NgParticlesModule ]
})
export class AppComponent {
  title = 'Todo list';
  isSignIn = false;
  id = "tsparticles";
  particlesOptions = {
    fullScreen: {
      enable: true,
      zIndex: -1 
    },
    background: {
        color: {
            value: "#0d47a1",
        },
    },
    fpsLimit: 120,
    interactivity: {
        events: {
            onClick: {
                enable: true,
                mode: ClickMode.push,
            },
            onHover: {
                enable: false,
                mode: HoverMode.repulse,
            },
            resize: true,
        },
        modes: {
            push: {
                quantity: 4,
            },
            repulse: {
                distance: 200,
                duration: 0.4,
            },
        },
    },
    particles: {
        color: {
            value: "#ffffff",
        },
        links: {
            color: "#ffffff",
            distance: 150,
            enable: true,
            opacity: 0.5,
            width: 1,
        },
        move: {
            direction: MoveDirection.none,
            enable: true,
            outModes: {
                default: OutMode.bounce,
            },
            random: false,
            speed: 6,
            straight: false,
        },
        number: {
            density: {
                enable: true,
                area: 800,
            },
            value: 80,
        },
        opacity: {
            value: 0.5,
        },
        shape: {
            type: "circle",
        },
        size: {
            value: { min: 1, max: 5 },
        },
    },
    detectRetina: true,
};

  particlesLoaded(container: Container): void {
    console.log(container);
}

async particlesInit(engine: Engine): Promise<void> {
    console.log(engine);
    await loadSlim(engine);
}
  constructor(public accountService: AccountService) {

  }
  ngOnInit(): void {
    this.setCurrentUser();
  }


  setCurrentUser(){
    const userString = localStorage.getItem('user');
    if(!userString){
      return;
    }
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
