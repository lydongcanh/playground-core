terraform {
  cloud {
    organization = "ted-playground"
    workspaces {
      name = "playground-core"
    }
  }
  required_providers {
    neon = {
      source = "kislerdm/neon"
    }
  }
}

provider "neon" {}
