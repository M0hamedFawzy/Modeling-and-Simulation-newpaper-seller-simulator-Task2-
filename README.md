# Newspaper Inventory Simulation Project

This project simulates a classical inventory problem involving the purchase and sale of newspapers. The goal is to determine the optimal number of newspapers a seller should purchase to maximize profit over a 20-day period.

## Problem Description

The paper seller buys newspapers for 33 cents each and sells them for 50 cents each. Unsold newspapers at the end of the day are sold as scrap for 5 cents each. Newspapers can only be purchased in bundles of 10 (e.g., 50, 60, etc.). There are three types of newsdays - “good,” “fair,” and “poor” - each with its own probability distribution.

## Simulation Details

The simulation will:
- Run for 20 days.
- Record daily profits based on demand, which varies depending on the type of newsday.
- Provide insights on the optimal number of newspapers to purchase.

### Parameters
- **Newspaper Purchase Price:** $0.33 per paper
- **Newspaper Selling Price:** $0.50 per paper
- **Newspaper Scrap Value:** $0.05 per paper
- **Number of Papers Purchased by News Dealer:** Varies by simulation
- **Probability distribution of news day types:** Good, Fair, Poor
- **Demand probability distribution for each day type:** Varies by day type

### Simulation Table Columns
1. **Day index**
2. **Random number for day type**
3. **Day type**
4. **Random number for demand**
5. **Demand (based on day type)**
6. **Revenue from sales**
7. **Lost profit from excess demand**
8. **Salvage from sale of scrap**
9. **Daily profit**

### Performance Measures
- Total Sales Revenue
- Total Cost of Newspapers
- Total Lost Profit from Excess Demand
- Total Salvage from sale of Scrap papers
- Net Profit
- Number of days having excess demand
- Number of days having unsold papers

## Deliverables
1. **Simulation Table for 20 Days:** Contains all the columns listed above.
2. **Performance Metrics:** Calculated from the simulation table, including total sales revenue, total cost of newspapers, total lost profit, total salvage, net profit, number of days with excess demand, and number of days with unsold papers.

## Running the Simulation

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd <repository-directory>
