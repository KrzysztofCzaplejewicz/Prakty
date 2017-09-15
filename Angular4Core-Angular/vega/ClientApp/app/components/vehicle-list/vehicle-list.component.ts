import { VehicleService } from './../../services/vehicle.service';
import { Vehicle, KeyValuePair } from './../../models/vehicle';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-vehicle-list',
    templateUrl: './vehicle-list.component.html',
    styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
    private readonly PAGE_SIZE = 3;
    vehicles: Vehicle[];
    makes: KeyValuePair[];
    query: any = {
        pageSize: this.PAGE_SIZE
    };
    columns = [
        { title: "Id" },
        { title: "make", key: 'make', isSortable: true },
        { title: "model", key: 'model', isSortable: true },
        { title: "contactName", key: 'contactName', isSortable: true }
    ];

    constructor(private vehicleService: VehicleService) { }

    ngOnInit() {
        this.vehicleService.getMakes()
            .subscribe(makes => this.makes = makes);

        this.populateFilters();
    }
    private populateFilters() {
        this.vehicleService.getVehicles(this.query)
            .subscribe(vehicles => this.vehicles = vehicles);
    }

    onFilterChange() {
        this.query.page = 1;
        this.query.pageSize = this.PAGE_SIZE;
        this.populateFilters();
    }

    resetFilter() {
        this.query = {
            page: 1,
            pageSize: this.PAGE_SIZE
        };
        this.populateFilters();
    }

    sortBy(columnName) {
        if (this.query.sortBy === columnName) {
            this.query.isSortAscending = !this.query.isSortAscending;
        }
        else {
            this.query.sortBy = columnName;
            this.query.isSortAscending = true;
        }
        this.populateFilters();
    }

    onPageChange(page) {
        this.query.page = page;
        this.populateFilters();
    }

}
