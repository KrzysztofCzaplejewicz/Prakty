import { VehicleService } from './../../services/vehicle.service';
import { Vehicle, KeyValuePair } from './../../models/vehicle';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[];  
  makes: KeyValuePair[];
  query: any = {};

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() 
  {
    this.vehicleService.getMakes()
    .subscribe(makes => this.makes = makes);

    this.populateFilters();
  }
  private populateFilters(){
    this.vehicleService.getVehicles(this.query)
    .subscribe(vehicles => this.vehicles = vehicles);
  }
  
  onFilterChange() {    
    this.populateFilters();
  }

  resetFilter() {
    this.query = {};
    this.onFilterChange();
  }

  sortBy(columnName) {
    if(this.query.sortBy === columnName) {
      this.query.isSortAsceding = false;
    }
    else {
      this.query.sortBy = columnName;
      this.query.isSortAsceding = true;
    }
    this.populateFilters();
  }

}
